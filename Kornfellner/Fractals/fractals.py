def level1(length, iter):
    for i in range(iter):
        length = length / 3 * 4

    return length * 3


def level2(length, iter):
    for i in range(iter):
        length = length / 3 * 5

    return length * 4


inputs = [(243, 3), (19683, 7), (531441, 7), (531441, 9)]

for (length, iter) in inputs:
    print("Length:", length, "Iterations:", iter)
    print("Level 1:", level1(length, iter),
          "|", "Level 2:", level2(length, iter))
    print()
