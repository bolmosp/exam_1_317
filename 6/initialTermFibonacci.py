def fibonacci(n):
    fib = [0, 1]
    
    print(fib[0])
    if n > 1:
        print(fib[1])
    
    for i in range(2, n):
        nextTerm = fib[0] + fib[1]
        print(nextTerm)
        
        fib[0] = fib[1]
        fib[1] = nextTerm


n = int(input("Nro. Fibonacci: "))
fibonacci(n)
