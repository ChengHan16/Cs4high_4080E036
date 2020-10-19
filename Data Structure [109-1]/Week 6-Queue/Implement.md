# 1.
```
#include <stdio.h>
#include <stdlib.h>

// Assume the data type is int

struct QueData{
	int value;
};

void movingData(struct QueueData array[],int start,int end);

int isEmpty(int frontIndex, int rearIndexd);
int isfull(int rearIndex, int queueSize);

int add(struct QueueData queue[],int *FrontIndex, int *pRearIndex, int *queueSize, struct QueueData *Data);

int del(struct QueueData queue[],int *pFrontIndex, int *pRearIndex, int *queueSize, struct QueueData *pData);

int viewRearData(struct QueueData queue[],int frontIndex, int rearIndex, int queueSize, struct QueueData *pData);

int viewFrontData(struct QueueData queue[],int frontIndex, int rearIndex, int queueSize, struct QueueData *pData);

int parseQueueData (struct QueueData data);

#define QueueSize 4

struct QueueData queue[QueueSize];
int front = -1;
int rear = -1;

int main(void){
	int queueState;
	int dataValue;
}
```
