from collections import Counter
import random

count = Counter()
result = []
for i in range (1, 6001):
    result.append(random.randrange(1, 7))
count.update(result)
print(count)