import math

pi = [0.15, 0.14, 0.13, 0.12, 0.11, 0.09, 0.08, 0.06, 0.05, 0.04, 0.02, 0.01]

shannon_fano = [3,3,3,3,3,3,4,4,5,5,5,5]
huffman = [3,3,3,3,3,3,4,4,4,5,6,6]

def counting(lenght):
       L = 0
       Lmin = 0
       
       for i in range(0,len(pi)):
              L += pi[i]*lenght[i]

       for i in range(0,len(pi)):
              Lmin += (pi[i] * math.log2(pi[i])) * (-1)

       #Lmin = abs(Lmin)
       X = Lmin/L
       print("L =",L)
       print("Lmin =",Lmin)
       print("X =",X)

print("\nШеннона-Фано:")
counting(shannon_fano)

print("\nХаффмана:")
counting(huffman)





