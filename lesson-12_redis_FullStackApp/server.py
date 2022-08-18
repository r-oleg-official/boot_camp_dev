import redis
import random

## Version with error 
#redis_server = redis.Redis() # create server on localhost by default.
#redis_server.close() # need always close connections
## Right version create Redis's server
with redis.Redis() as redis_server:
    #redis_server.lpush("queue", 5)
    redis_server.lpush("queue", random.randint(0, 10))