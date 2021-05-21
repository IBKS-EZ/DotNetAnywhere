#if !defined(__LTL_H)
#define __LTL_H

#include "MetaData.h"

#define VECTOR(type) \
typedef struct Vector##type##_ {\
  type*     pElements;\
  U32       dwCounter;\
  U32       dwSize;\
} Vector##type;\
void Reallocate##type##Vector(Vector##type *vector);\
void Allocate##type##Vector(Vector##type *vector);\
Vector##type Vector##type##_init(U32  size);\
void Push##type##Vector(Vector##type * vector, type element);

typedef struct StringLTL_ {
  char* lpsData;
  U32   dwLength;

} StringLTL;

typedef StringLTL OperatorName;
typedef StringLTL OperatorArg;
typedef StringLTL StateLTL;

VECTOR(OperatorArg)

typedef struct OperatorLTL_ {
  OperatorName      onOperator;
  VectorOperatorArg oaArgs;
  
} OperatorLTL;

VECTOR(OperatorLTL)
VECTOR(StateLTL)

typedef struct ConfigureLTL_{
  tMD_MethodDef       *pMethod;
  StateLTL            ltlState;
  VectorOperatorLTL   ltlOperators;
}ConfigureLTL;

//typedef struct VectorAttributeLTL_ {
//  AttributeLTL* tltAttributes;
//  U32       dwCounter;
//  U32       dwSize;
//}VectorAttributeLTL;



//typedef struct StackLTL_ {
//  StateLTL  *ltlState;
//  U32       dwIP;
//  U32       dwStackSize;
//}StackLTL;

typedef struct FutureLTL_ {
  VectorStateLTL  ltlState;
  U32             dwStateLimit;
}FutureLTL;

//typedef struct FutureStackLTL_ {
//  FutureLTL* ltlFuture;
//  U32       dwIP;
//  U32       dwStackSize;
//};

VECTOR(FutureLTL)
VECTOR(ConfigureLTL)

typedef struct LTL_ {
  VectorStateLTL ltlStack;
  StateLTL  ltlStateNext;

  U32  dwStateCounter;
  
  VectorFutureLTL  ltlFutureStates;
  //GlobalLTL*  ltlGlobalStates;
  // TODO: сохранить последнеее корректное состояние

} LTL;

void LTL_init(tMetaData* pMetaData);
//void PushVector(VectorConfigureLTL* vector, ConfigureLTL element);

#endif // __LTL_H