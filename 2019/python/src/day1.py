from src.utils import get_inputs_as_ints
from functools import reduce

def fuel_requirements_for_module(module_mass: int) -> int:
    """

    Fuel required to launch a given module is based on its
    mass. Specifically, to find the fuel required for a module, take
    its mass, divide by three, round down, and subtract 2.

    >>> fuel_requirements_for_module(12)
    2

    >>> fuel_requirements_for_module(14)
    2

    >>> fuel_requirements_for_module(1969)
    654

    >>> fuel_requirements_for_module(100756)
    33583

    """
    return (module_mass // 3) - 2

def fuel_requirements_for_modules(modules):
    accumulation = 0

    for module_mass in modules:
        accumulation += fuel_requirements_for_module(module_mass)

    return accumulation

def solve():
    inputs = get_inputs_as_ints(1)
    return fuel_requirements_for_modules(inputs)
    
