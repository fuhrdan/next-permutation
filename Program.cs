//*****************************************************************************
//** 31. Next Permutation Leetcode                                           **
//** I started with a simple find and sort, which caused some errors in      **
//** later cases, so I changed to simple find lartest placement, swap and    **
//** sort.  This is a slow answer written in C.  With some optimization it   **
//** can work better.  - Dan                                                 **
//*****************************************************************************

void nextPermutation(int* nums, int numsSize) {
    int placement = -1;
    int min = 0;
    int temp = 0;
    for (int i = numsSize - 1; i > 0; i--)
    {
        if(nums[i] > nums[i-1])
        {
            placement = i - 1;
            min = i;
            break;
        }
    }
    if(placement == -1)
    {
        for(int j = 0; j < numsSize-1; j++)
        {
            for(int k = 0; k < numsSize - j - 1; k++)
            {
                if(nums[k] > nums[k+1])
                {
                    temp = nums[k];
                    nums[k] = nums[k+1];
                    nums[k+1] = temp;
                }
            }
        }
        return;
    }
    for(int i = placement + 1; i < numsSize; i++)
    {
        if(nums[i] > nums[placement] && nums[i] < nums[min])
        {
            min = i;
        }
    }
    temp = nums[placement];
    nums[placement] = nums[min];
    nums[min] = temp;
    for(int j = placement + 1; j < numsSize; j++)
    {
//        printf("Final Loop j = %d placement = %d\n",j,placement);
        for(int k = placement + 1; k < numsSize - 1; k++)
            {
//                printf("nums[%d] = %d and nums[%d] = %d\n",k,nums[k],k+1,nums[k+1]);
                if(nums[k] > nums[k+1])
                {
                    temp = nums[k];
                    nums[k] = nums[k+1];
                    nums[k+1] = temp;
                }
            }
    }

}