from src.utils import get_inputs, split_by_size
from typing import List


def solve_op(mem: List[int], opcode: int, pos_1: int, pos_2: int, pos_result: int):
    """
    Calculates the result of applying the opcode on the args available
    on pos_1 and pos_2. Saves the result at pos_result.

    """
    print(opcode)
    return
    
    arg_1 = mem[pos_1]
    arg_2 = mem[pos_2]

    result = None

    if opcode is 1:
        result = arg_1 + arg_2
    elif opcode is 2:
        result = arg_1 + arg_2
    elif opcode is 99:
        pass
    else:
        raise ValueError("Improper opcode: {}".format(opcode))

    return result

def solve():
    # The generator will have a single value. Converting this a list
    # to get the comma separated string of ints.
    inputs = list(get_inputs(2))
    for sequence in inputs:
        for subsequences in split_by_size(sequence.split(","), 4):
            print(subsequences)
            solve_op(*subsequences)
        

