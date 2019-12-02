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

def fuel_requirements_for_module_and_fuel(module_mass: int) -> int:
    """

    Fuel itself requires fuel just like a module - take its mass,
    divide by three, round down, and subtract 2. However, that fuel also
    requires fuel, and that fuel requires fuel, and so on. Any mass that
    would require negative fuel should instead be treated as if it
    requires zero fuel; the remaining mass, if any, is instead handled by
    wishing really hard, which has no mass and is outside the scope of
    this calculation.

    >>> fuel_requirements_for_module_and_fuel(12)
    2

    >>> fuel_requirements_for_module_and_fuel(1969)
    966

    >>> fuel_requirements_for_module_and_fuel(100756)
    50346

    """
    fuel_for_module = fuel_requirements_for_module(module_mass)
    total_fuel = fuel_for_module

    while fuel_for_module > 0:
        fuel_for_fuel = fuel_requirements_for_module(fuel_for_module)
        if fuel_for_fuel <= 0:
            break
        total_fuel += fuel_for_fuel
        fuel_for_module = fuel_for_fuel
    
    return total_fuel
    

def fuel_requirements_for_modules(modules):
    accumulation = 0

    for module_mass in modules:
        accumulation += fuel_requirements_for_module(module_mass)

    return accumulation

def fuel_requirements_for_modules_and_fuels(modules):
    accumulation = 0

    for module_mass in modules:
        accumulation += fuel_requirements_for_module_and_fuel(module_mass)

    return accumulation


def solve():
    inputs = get_inputs_as_ints(1)
    return fuel_requirements_for_modules_and_fuels(inputs)
    
