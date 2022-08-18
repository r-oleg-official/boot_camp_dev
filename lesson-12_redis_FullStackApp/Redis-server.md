## Install to Linux Mint 20.

    $ curl -fsSL https://packages.redis.io/gpg | sudo gpg --dearmor -o /usr/share/keyrings/redis-archive-keyring.gpg
    
    $ echo "deb [signed-by=/usr/share/keyrings/redis-archive-keyring.gpg] https://packages.redis.io/deb $(lsb_release -cs) main" | sudo tee /etc/apt/sources.list.d/redis.list
    
    $ sudo apt update && sudo apt install redis

## Configuration Redis-server.
`Redis` можно запустить без файла конфигурации, используя встроенную конфигурацию по умолчанию.

Вы можете увеличить максимальный лимит памяти в соответствии с доступной на вашем сервере:

    $ sudo nano /etc/redis/redis.conf

Edit:

    maxmemory 512mb
    maxmemory-policy allkeys-lru

Приведенная выше конфигурация сообщает `Redis` об удалении любого ключа с использованием алгоритма LRU при достижении максимального объема памяти **512 МБ**. После внесения любых изменений перезапустите службу один раз.

Service:

    $ sudo systemctl status redis-server.service

    $ sudo systemctl restart redis-server.service
    
    $ sudo systemctl disable redis-server.service

Start redis-server to terminal:

    $ redis-cli

### Project.
Install Redis-server to path of the project:

    $ pip install redis

### Commands to terminal of the `Redis`
Syntax of [commands](https://redis.io/commands/info/):

    > ping
    Pong - server's Ok
    > set [name_key] - create a new key with a name "name_key"
    > get name_key - print element with name key "name_key"
    > KEYS * - print all keys
    > LRANGE queue 0 -1 - print all elements in list "queue" 

### Sources:
1. [Redis's official](https://redis.io/docs/getting-started/installation/install-redis-on-linux/)
2. [Как установить Redis на Linux Mint 20](https://infoit.com.ua/linux/kak-ustanovit-redis-na-linux-mint-20/)