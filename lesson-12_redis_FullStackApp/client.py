import redis

with redis.Redis() as redis_client:
    #value = redis_client.rpop("queue")
    value = redis_client.brpop("queue") # b - wait data in queue
print(value)            # view as bytes
#print(int(value))      # view as number
print(value[1])         # view as bytes, first element
print(int(value[1]))    # view as bytes, first element, integer