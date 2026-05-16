def triangle_perimeter(a, b, c):
    if a <= 0 or b <= 0 or c <= 0:
        raise ValueError("Стороны должны быть положительными")
    if a > 100 or b > 100 or c > 100:
        raise ValueError("Стороны не должны превышать 100")
    if a + b <= c or a + c <= b or b + c <= a:
        raise ValueError("Не треугольник")
    return a + b + c

import pytest

def test_boundary_min():
    assert triangle_perimeter(1, 1, 1) == 3

def test_boundary_min_plus_one():
    assert triangle_perimeter(2, 2, 2) == 6

def test_boundary_nominal():
    assert triangle_perimeter(50, 50, 50) == 150

def test_boundary_max_minus_one():
    assert triangle_perimeter(99, 99, 99) == 297

def test_boundary_max():
    assert triangle_perimeter(100, 100, 100) == 300

def test_boundary_combinations():
    assert triangle_perimeter(1, 50, 50) == 101
    
    with pytest.raises(ValueError, match="Не треугольник"):
        triangle_perimeter(100, 50, 50)