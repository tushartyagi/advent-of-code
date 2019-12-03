import os.path
from typing import Iterable

DIR_INPUTS = "~/coding/advent-of-code/2019/inputs"

def get_inputs(day) -> Iterable[str]:
    input_path = os.path.expanduser(os.path.join(DIR_INPUTS, "day{}.txt".format(day)))
    with open(input_path, "r") as f:
        for line in f:
            yield line

def get_inputs_as_ints(day):
    for input in get_inputs(day):
        yield int(input)


def split_by_size(elements, split_size):
    """Given an input of elements, yields groups of sub-elements, with
    group-size being split_size.

    >>> list(split_by_size([1, 2, 3, 4], 2))
    [[1, 2], [3, 4]]

    >>> list(split_by_size([], 5))
    []

    """    
    for i in range(0, len(elements), split_size):
        yield elements[i:split_size + i]
