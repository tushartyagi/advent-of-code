from src.utils import get_inputs_as_ints
from functools import reduce

def fuel_requirements_for_module(module_mass):
    return (module_mass // 3) - 2

def fuel_requirements_for_modules(modules):
    accumulation = 0

    for module_mass in modules:
        accumulation += fuel_requirements_for_module(module_mass)

    return accumulation

def solve():
    inputs = get_inputs_as_ints(1)
    return fuel_requirements_for_modules(inputs)
    
