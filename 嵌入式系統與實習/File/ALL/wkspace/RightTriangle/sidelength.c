/*
 * sidelength.c
 *
 *  Created on: Oct 25, 2016
 *      Author: Jhou
 */
#include <math.h>
#define uint32_t unsigned int
uint32_t  int_sqrt(uint32_t);
double sidelength(double i, double j)
{
	return  sqrt(i*i+j*j);
}

/*
uint32_t  int_sqrt(uint32_t a_nInput)
{
	uint32_t op  = a_nInput;
	    uint32_t res = 0;
	    uint32_t one = 1uL << 30; // The second-to-top bit is set: use 1u << 14 for uint16_t type; use 1uL<<30 for uint32_t type


	    // "one" starts at the highest power of four <= than the argument.
	    while (one > op)
	    {
	        one >>= 2;
	    }

	    while (one != 0)
	    {
	        if (op >= res + one)
	        {
	            op = op - (res + one);
	            res = res +  2 * one;
	        }
	        res >>= 1;
	        one >>= 2;
	    }
	    return res;
}
*/