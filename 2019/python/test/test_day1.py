from src.day1 import fuel_requirements_for_module
from src.day1 import fuel_requirements_for_modules

def test_1_level_of_fuel_works():
    assert fuel_requirements_for_module(12) == 2
    assert fuel_requirements_for_module(14) == 2
    assert fuel_requirements_for_module(1969) == 654
    assert fuel_requirements_for_module(100756) == 33583

def test_1_level_of_fuel_works_for_modules():    
    assert fuel_requirements_for_modules([12, 14]) == 4
