#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

int main()
{
    int hor = 0;
    int min = 0;
    int seg = 0;

    while(1) {
        printf("%d:%d:%d", hor, min, seg);

        if (seg == 60) {
            seg = 0;
            min++;
        }

        if (min == 60) {
            min = 0;
            hor++;
        }

        if (hor == 24) {
            hor = 0;
        }

        sleep(1);
        seg++;

        system("cls");
    }

    return 0;
}
