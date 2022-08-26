from random import randint

#x = randint(0, 100)

# ф-ция последовательного перебора
## count = 0
## for i in range(0, 101):
##     count += 1
##     if i ==  x:
##         print ("Number find!")
##         break
## print("Source the number:", x, "Number of iteration:", count)

#Random function search x
## count = 1
## y = randint(0, 100)
## while x != y:
##     y = randint(0, 100)
##     count += 1
## print("Source the number:", x, "Number of iteration:", count)

## # Interactive Binary search source number
## count_bin = 0
## print("Let's go to game!")
## y = int(input("Enter a number: "))
## while x != y:
##     count_bin += 1
##     if x < y: print("number is lower")
##     else: print("number is higher")
##     y = int(input("Enter a number: "))
## 
## print("Source the number:", x, "Number of iteration:", count_bin)

# My Binary search source number
count_bin = 1
low = 0
high = 100000
x = randint(low, high)
#y = (high - low) // 2
#y = randint(low, high)
y = high
while x != y:
    print(y)
    y = (high - low) // 2 # // - делить нацело
    if x < y: 
        high = high - y
    if x > y: 
        low = low + y
    
    count_bin += 1
    #if y == 0: break

print("Source:", x, " Find:", y, " Number of iteration:", count_bin)

## ## Version Timur
## left = 0
## right = 100
## x = randint(left, right)
## count_bin = 1
## mid = (right + left) // 2
## while x != mid:
##     print(mid)
##     if x < mid: right = mid - 1
##     else: left = mid + 1
##     mid = (right + left) // 2
##     count_bin += 1
## print("Source:", x, " Find:", mid, " Number of iteration:", count_bin)