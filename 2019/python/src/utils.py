import os.path

DIR_INPUTS = "~/coding/advent-of-code/2019/inputs"

def get_inputs(day):
    input_path = os.path.expanduser(os.path.join(DIR_INPUTS, "day{}.txt".format(day)))
    with open(input_path, "r") as f:
        for line in f:
            yield line

def get_inputs_as_ints(day):
    for input in get_inputs(day):
        yield int(input)
