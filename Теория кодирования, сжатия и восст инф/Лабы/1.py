pi = [0.15, 0.14, 0.13, 0.12, 0.11, 0.09, 0.08, 0.06, 0.05, 0.04, 0.02, 0.01]
#lenght = [3,3,3,3,3,3,4,4,5,5,5,5]
lenght = [3,3,3,3,3,3,4,4,4,5,6,6]
L = 0

for i in range(0,len(pi)):
       L += pi[i]*lenght[i]
       print(i+1, L)

print("L =",L)
Lmin = lenght[1]
print("Lmin =",Lmin)
X = Lmin/L
print("X =",X)
