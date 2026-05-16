def triangle_type(a, b, c):
    if a <= 0 or b <= 0 or c <= 0:
        return "Не треугольник"

    if a + b <= c or a + c <= b or b + c <= a:
        return "Не треугольник"

    if a == b == c:
        return "Равносторонний"
    elif a == b or b == c or a == c:
        return "Равнобедренный"
    else:
        return "Разносторонний"
    
def test_equilateral():
    assert triangle_type(5, 5, 5) == "Равносторонний"

def test_isosceles():
    assert triangle_type(5, 5, 7) == "Равнобедренный"
    assert triangle_type(6, 4, 6) == "Равнобедренный"

def test_scalene():
    assert triangle_type(3, 4, 5) == "Разносторонний"

def test_not_triangle_zero():
    assert triangle_type(0, 4, 5) == "Не треугольник"

def test_not_triangle_negative():
    assert triangle_type(-1, 2, 3) == "Не треугольник"

def test_not_triangle_inequality():
    assert triangle_type(1, 1, 3) == "Не треугольник"
    assert triangle_type(10, 2, 3) == "Не треугольник"