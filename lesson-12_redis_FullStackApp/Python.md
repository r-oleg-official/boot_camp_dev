## Install Python to Mint 20.

    $ sudo apt-get install python3 python3-venv python3-pip
    $ sudo apt install python3.9

Add to `~/.basrc`:

    export PYTHONPATH=/usr/bin/python3
    
or

    export PYTHONHOME=/usr/bin/python3

For start in terminal python's script `script.py` of command:

    $ python script.py

Need add to `~/.basrc`:

    alias python="/usr/bin/python3"

## VS Code & Python

    $ sudo apt install pip

Need add to `~/.basrc`:

    alias pip="/usr/bin/pip"

Add plugin to `VSC`. Extension -> Find: Python. (by MSFT, IntelliSence (Pylance)).
