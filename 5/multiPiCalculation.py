import multiprocessing as mp

def calculate_partial(start, end, result):
    partial_sum = 0.0
    sign = 1 if start % 2 == 0 else -1
    for i in range(start, end):
        partial_sum += sign * (4.0 / (2 * i + 1))
        sign = -sign
    result.put(partial_sum)

def calculate_pi_multiprocessing(n, num_process):
    result = mp.Queue()

    iterations_per_process = n // num_process
    processes = []

    for i in range(num_processes):
        start = i * iterations_per_process
        end = (i + 1) * iterations_per_process if i != num_processes - 1 else n
        process = mp.Process(target=calculate_partial, args=(start, end, result))
        processes.append(process)
        process.start()

    for process in processes:
        process.join()

    pi_aproximated = 0.0
    while not result.empty():
        pi_aproximated += result.get()

    return pi_aproximated

if __name__ == '__main__':
    n = 1000000
    num_processes = 3 

    pi = calculate_pi_multiprocessing(n, num_processes)
    print(f"Resultado: {pi:.15f}")
