import json
import re


def read_and_add():
    with open("input12.txt") as f:
        values = f.read()
        r = re.compile(r"-?\d+")
        numbers = r.findall(values)
        sum = 0
        for num in numbers:
            sum += int(num)
        return sum


def read_and_add2():
    with open("input12.txt") as f:
        j = json.load(f)

        s = do_sum(j)
        print(s)


def do_sum(arg, ignore_red=False):
    sum_value = 0

    if type(arg) is str:
        sum_value += sum_string(arg)
    elif type(arg) is int:
        sum_value += arg
    elif type(arg) is list:
        sum_value += sum([do_sum(x) for x in arg])
    elif type(arg) is dict:
        if ignore_red and "red" in arg.values():
            return 0
        else:
            for k, v in arg.items():
                sum_value += do_sum(v)

    return sum_value


def sum_string(s):
    c = 0
    try:
        c = int(s)
    except ValueError:
        pass

    return c
