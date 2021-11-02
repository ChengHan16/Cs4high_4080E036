/*
 * main.c
 *
 *  Created on: Oct 25, 2016
 *      Author: Jhou
 */
#include <stdio.h>
#include <stdlib.h>
extern double area_cal();
extern double sidelength();
#include "side.h"

int main(void)
{
	//float side_a=25, side_b=100;
	double area;
	double side_c;
	side_c = sidelength((double)side_a, (double) side_b);
	area = area_cal((double)side_a, (double)side_b);
	printf("THe length of the third side is %5.2lf\n", side_c);
	printf("The area of this right triangle is %5.2lf\n", area);
	return EXIT_SUCCESS;
}

