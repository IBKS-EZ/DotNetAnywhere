#include "Compat.h"
#include "LTL.h"

#include "Sys.h"

static LTL MachineLTL;
static VectorConfigureLTL ProgramConfigures;

static const OperatorName MachineOperators[] = {
  {"Next", 4},
  {"Until", 5},
  {"Future", 6},
  {"Global", 6},
  {"Release", 7}
};
#define NEXT_TABLE_INDEX 0
#define UNTIL_TABLE_INDEX 1
#define FUTURE_TABLE_INDEX 2
#define GLOBAL_TABLE_INDEX 3
#define RELEASE_TABLE_INDEX 4

//void* SmartAlloc(void * pointer, size_t size) {
//  if (pointer) {
//    return realloc(pointer, size);
//  }
//  else {
//    return calloc(size, 1);
//  }
//}

#define VECTOR_ALLOC_SIZE 20
#define FUTURE_LIMIT 2

#define VECTOR_ALLOCATOR(type)\
void Allocate##type##Vector(Vector##type *vector, U32 size) {\
  vector->dwSize = size;\
  vector->dwCounter = 0;\
  vector->pElements = (type*)calloc(vector->dwSize, sizeof(type));\
}


#define VECTOR_REALLOCATOR(type)\
void Reallocate##type##Vector(Vector##type* vector) {\
  vector->dwSize += VECTOR_ALLOC_SIZE;\
  type* NewElements = (type*)realloc(vector->pElements, vector->dwSize * sizeof(type));\
  if (NewElements){\
    vector->pElements = NewElements; \
  }\
}

#define VECTOR_INIT(type)\
Vector##type Vector##type##_init(U32 size) {\
  Vector##type vector = {NULL, 0, 0};\
  Allocate##type##Vector(&vector, size);\
  return vector;\
}

#define VECTOR_PUSH(type)\
void Push##type##Vector(Vector##type * vector, type element) {\
  if (vector->dwSize == vector->dwCounter) {\
    Reallocate##type##Vector(vector);\
  }\
  vector->pElements[vector->dwCounter] = element;\
  vector->dwCounter += 1;\
}

#define ERASE_ELEMENT_VECTOR(type)\
void EraseElement##type##Vector(Vector##type *vector, U32 index) {\
  memcpy(&vector->pElements[index], &vector->pElements[index + 1], (vector->dwCounter - index - 1) * sizeof(type));\
  vector->dwCounter = 0;\
}

#define GET_LAST_VECTOR(type)\
type GetLast##type##Vector(Vector##type vector) {\
  return vector.pElements[vector.dwCounter - 1];\
}


VECTOR_ALLOCATOR(StateLTL)
VECTOR_ALLOCATOR(FutureLTL)
VECTOR_ALLOCATOR(ConfigureLTL)
VECTOR_ALLOCATOR(OperatorLTL)
VECTOR_ALLOCATOR(OperatorArg)

VECTOR_REALLOCATOR(StateLTL)
VECTOR_REALLOCATOR(FutureLTL)
VECTOR_REALLOCATOR(ConfigureLTL)
VECTOR_REALLOCATOR(OperatorLTL)
VECTOR_REALLOCATOR(OperatorArg)

VECTOR_INIT(StateLTL)
VECTOR_INIT(FutureLTL)
VECTOR_INIT(ConfigureLTL)
VECTOR_INIT(OperatorLTL)
VECTOR_INIT(OperatorArg)

VECTOR_PUSH(StateLTL)
VECTOR_PUSH(FutureLTL)
VECTOR_PUSH(ConfigureLTL)
VECTOR_PUSH(OperatorLTL)
VECTOR_PUSH(OperatorArg)

GET_LAST_VECTOR(StateLTL)
GET_LAST_VECTOR(FutureLTL)
GET_LAST_VECTOR(ConfigureLTL)
GET_LAST_VECTOR(OperatorLTL)
GET_LAST_VECTOR(OperatorArg)

ERASE_ELEMENT_VECTOR(FutureLTL)

ConfigureLTL* IsConfigureExists(VectorConfigureLTL attributes, tMD_MethodDef *pMethod) {
  for (U32 i = 0; i < attributes.dwCounter; i++) {
    if (attributes.pElements[i].pMethod == pMethod) {
      return &attributes.pElements[i];
    }
  }

  return NULL;
}

I32 CompareStringLTL(StringLTL str1, StringLTL str2) {
  return strncmp(str1.lpsData, str2.lpsData, min(str1.dwLength, str1.dwLength));
}

void LTL_init(tMetaData* pMetaData) {

  MachineLTL.dwStateCounter = 0;
  MachineLTL.ltlStateNext.lpsData = NULL;
  MachineLTL.ltlStateNext.dwLength = 0;
  MachineLTL.ltlStack = VectorStateLTL_init(20);
  MachineLTL.ltlFutureStates = VectorFutureLTL_init(20);

  ProgramConfigures = VectorConfigureLTL_init(20);

  for (U32 i = pMetaData->tables.numRows[MD_TABLE_CUSTOMATTRIBUTE]; i > 0; i--) {

    tMD_CustomAttribute* pCustomAttribute;
    tMD_MethodDef* pMethodDef_parent;
    tMD_MethodDef* pMethodDef_ctor;
    tMD_TypeDef* pTypeDef;

    U32 blob_len = 0;
    PTR blob = NULL;
    U32 values_lens[3] = { 0, 0, 0 };
    PTR values[3] = {NULL, NULL, NULL};

    U32 value_cnt = 0;

    pCustomAttribute = MetaData_GetCustomAttribute(pMetaData, MAKE_TABLE_INDEX(MD_TABLE_CUSTOMATTRIBUTE, i));
    if (TABLE_ID(pCustomAttribute->parent) != MD_TABLE_METHODDEF) {
      continue;
    }

    pMethodDef_parent = MetaData_GetParentMethodFromCustomAttribute(pMetaData, pCustomAttribute);
    pMethodDef_ctor = MetaData_GetTypeMethodFromCustomAttribute(pMetaData, pCustomAttribute);
    pTypeDef = MetaData_GetTypeDefFromMethodDef(pMethodDef_ctor);

    blob_len = 0;
    blob = MetaData_GetBlob(pCustomAttribute->value, &blob_len);

    value_cnt = MetaData_GetValuesFromBlob(blob, blob_len, values, values_lens);


    ConfigureLTL* Configure = IsConfigureExists(ProgramConfigures, pMethodDef_parent);
    if (Configure) {
      StateLTL State = { values[0], values_lens[0] };
      if (CompareStringLTL(Configure->ltlState, State)) {
        Crash("Model Checking Error: One method have several states: %s", pMethodDef_parent->name);
      }
    }
    else {
      ConfigureLTL NewConfigure;
      NewConfigure.ltlOperators = VectorOperatorLTL_init(1);

      NewConfigure.pMethod = pMethodDef_parent;

      NewConfigure.ltlState.lpsData = values[0];
      NewConfigure.ltlState.dwLength = values_lens[0];

      PushConfigureLTLVector(&ProgramConfigures, NewConfigure);

      Configure = &ProgramConfigures.pElements[ProgramConfigures.dwCounter-1];
    }

    OperatorLTL NewOperator;

    NewOperator.onOperator.lpsData = pTypeDef->name;
    NewOperator.onOperator.dwLength = strlen(pTypeDef->name);
    
    //TODO: сделать цикл
    NewOperator.oaArgs = VectorOperatorArg_init(1);

    OperatorArg NewOperatorArg;

    NewOperatorArg.lpsData  = values[1];
    NewOperatorArg.dwLength = values_lens[1];
    PushOperatorArgVector(&NewOperator.oaArgs, NewOperatorArg);

    PushOperatorLTLVector(&Configure->ltlOperators, NewOperator);

  }
}

ConfigureLTL* ConfigureOnMethod(tMD_MethodDef* pMethod) {
  for (U32 i = 0; i < ProgramConfigures.dwCounter; i++) {
    if (ProgramConfigures.pElements[i].pMethod == pMethod) {
      return &ProgramConfigures.pElements[i];
    }
  }
  return NULL;
}

BOOL ValidateNext(ConfigureLTL* Configure) {
  if (MachineLTL.ltlStateNext.lpsData != NULL && CompareStringLTL(MachineLTL.ltlStateNext, Configure->ltlState)) {
    return FALSE;
  }
  return TRUE;
}

BOOL ValidateUntil(OperatorLTL Operator) {
 
  if (!CompareStringLTL(Operator.onOperator, MachineOperators[UNTIL_TABLE_INDEX])) {
    if (CompareStringLTL(Operator.oaArgs.pElements[0], GetLastStateLTLVector(MachineLTL.ltlStack))) {
      return FALSE;
    }
  }

  return TRUE;
}

BOOL ValidateFuture(ConfigureLTL* Configure) {
  for (U32 i = 0; i < MachineLTL.ltlFutureStates.dwCounter; i++) {
    if (!CompareStringLTL(MachineLTL.ltlFutureStates.pElements[i].ltlState, Configure->ltlState)) {
      EraseElementFutureLTLVector(&MachineLTL.ltlFutureStates, i);
    }
    else {
      if (MachineLTL.ltlFutureStates.pElements[i].dwStateLimit < MachineLTL.dwStateCounter) {
        return FALSE;
      }
    }
  }
  return TRUE;
}

void SetNext(OperatorLTL Operator) {
  if (!CompareStringLTL(Operator.onOperator, MachineOperators[NEXT_TABLE_INDEX])) {
    MachineLTL.ltlStateNext = Operator.oaArgs.pElements[0];
  }
}

void SetFuture(OperatorLTL Operator) {
  if (!CompareStringLTL(Operator.onOperator, MachineOperators[FUTURE_TABLE_INDEX])) {
    FutureLTL NewFuture = { Operator.oaArgs.pElements[0], MachineLTL.dwStateCounter + FUTURE_LIMIT };
    PushFutureLTLVector(&MachineLTL.ltlFutureStates, NewFuture);
  }
}

void RunOnMethodLTL(tMD_MethodDef* pMethod) {
  ConfigureLTL* Configure = ConfigureOnMethod(pMethod);
  if (!Configure) {
    return;
  }

  //Validate Next
  if (ValidateNext(Configure)) {
    MachineLTL.ltlStateNext.lpsData = NULL;
  }
  else {
    Crash("Model Checking Error: Expected state %.*s, received %.*s, on method: %s",
      MachineLTL.ltlStateNext.lpsData ,MachineLTL.ltlStateNext.lpsData,
      Configure->ltlState.dwLength, Configure->ltlState.lpsData,
      pMethod->name);
  }

  //ValidateFuture
  if (!ValidateFuture(Configure)) {
    printf("\n\n");
    printf("Current state counter = %d\n", MachineLTL.dwStateCounter);
    for (U32 i = 0; i < MachineLTL.ltlFutureStates.dwCounter; i++) {
      printf("Future state number %d: %.*s with limit %d", i,
        MachineLTL.ltlFutureStates.pElements[i].ltlState.dwLength, MachineLTL.ltlFutureStates.pElements[i].ltlState.lpsData,
        MachineLTL.ltlFutureStates.pElements[i].dwStateLimit);
    }
    Crash("Model Checking Error: one or more Future States are expired, on method: %s",
      pMethod->name);
  }

  for (U32 j = 0; j < Configure->ltlOperators.dwCounter; j++) {

    //Validate Until
    if (!ValidateUntil(Configure->ltlOperators.pElements[j])) {
      Crash("Model Checking Error: Previous state must be %.*s, but %.*s, on method: %s",
        Configure->ltlOperators.pElements[j].oaArgs.pElements[0].dwLength, Configure->ltlOperators.pElements[j].oaArgs.pElements[0].lpsData,
        GetLastStateLTLVector(MachineLTL.ltlStack).dwLength, GetLastStateLTLVector(MachineLTL.ltlStack).lpsData,
        pMethod->name);
    }

    //SetNext
    SetNext(Configure->ltlOperators.pElements[j]);


    //SetFuture
    SetFuture(Configure->ltlOperators.pElements[j]);  
      
  }

  PushStateLTLVector(&MachineLTL.ltlStack, Configure->ltlState);
  MachineLTL.dwStateCounter += 1;
}