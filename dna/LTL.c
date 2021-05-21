#include "Compat.h"
#include "LTL.h"

static LTL MachineLTL;
static VectorConfigureLTL ProgramConfigures;


//void* SmartAlloc(void * pointer, size_t size) {
//  if (pointer) {
//    return realloc(pointer, size);
//  }
//  else {
//    return calloc(size, 1);
//  }
//}

#define VECTOR_ALLOC_SIZE 20

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


ConfigureLTL* IsConfigureExists(VectorConfigureLTL attributes, tMD_MethodDef *pMethod) {
  for (U32 i = 0; i < attributes.dwCounter; i++) {
    if (attributes.pElements[i].pMethod == pMethod) {
      return &attributes.pElements[i];
    }
  }

  return NULL;
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
      if (values[0] != Configure->ltlState.lpsData) {
        //TODO: throught error state names not equal
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


void RunOnMethodLTL(tMD_MethodDef* pMethodDef) {


}