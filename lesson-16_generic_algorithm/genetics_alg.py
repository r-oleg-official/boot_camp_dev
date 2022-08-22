from random import randint

# Class "Chromosome" with the third options:
# 1. rating - chromosome's rating;
# 2. size - chroosome's size (length array of the genes);
# 3. genes - the array chromosome's genes (it's chroosome was been in start process).

class Chromosome:
    def __init__(self, size, gene_pool):
        self.rating = 0
        self.size = size
        self.genes = bytearray(size)
        if gene_pool is not None:
            self.set_random_genes(gene_pool)
    
    # Теперь напишем ф-цию для генерации случ хромосомы. Ф-ция принимает два параметра:
    # длина хромосомы, которую надо получить и набор генов, из которого 
    # нужно сделать хромосому.
 
    def set_random_genes(self, gene_pool):
        gene_pool_range = len(gene_pool) - 1
        for i in range(self.size):
            rand_pos = randint(0, gene_pool_range)
            self.genes[i] = gene_pool[rand_pos]

def create_population(pop_size, chromo_size, genes):
    # В ф-цию заполнения популяции мы также передаем размер популяции,
    # размер хромосомы и генофонд, чтобы не зависеть от глобальных переменных.
    # Подбор пар
    # генофонд (все англ буквы + пробел)
    # размер хромосомы - длина строки

    population = [None] * pop_size
    for i in range(pop_size):
        population[i] = Chromosome(chromo_size, gene_pool)
    return population

# Ф-ция для вычисления рейтинга - расстояния между двумя строками.
# Напишем сразу для всей популяции, т.к. др. прим.-й у нее нет:

def calc_rating(population, final_chromo):
    for chromo in population:
        chromo.rating = chromo.size
        for i in range(chromo.size):
            if chromo.genes[i] == final_chromo[i]:
                chromo.rating -= 1

# Сделаем сорт-ку хромосом по рейтингу. Это обычная сортировка пузырем:

def sort_population(population):
    size = len(population)
    repeat = True
    while repeat:
        repeat = False
        for i in range(0, size - 1):
            bubble = population[i]
            if (bubble.rating > population[i + 1].rating):
                population[i] = population[i + 1]
                population[i + 1] = bubble
                repeat = True

def select(population, survivors):
    # elitism selection
    size = len(survivors)
    for i in range(size):
        survivors[i] = population[i]

def repopulate(population, parents, children_count):
    # Теперь, имея функции для выбора родителей и для скрещивания, пишем ф-цию,
    # которая заполняет вторую половину популяции потомками 
    # (родители сохраняются в первой половине)
    pop_size = len(population)
    while children_count < pop_size:
        p1_pos = get_parent_index(parents, None)
        p2_pos = get_parent_index(parents, p1_pos)
        p1 = parents[p1_pos]
        p2 = parents[p2_pos]
        population[children_count] = cross(p1, p2)
        population[children_count + 1] = cross(p2, p1)
        children_count += 2

def get_parent_index(parents, exclude_index):
    # Среди выживших нужно отобрать пары родителей для того, чтобы получить
    # от них потомков и восстановить вторую половину популяции
    size = len(parents)
    while True:
        index = randint(0, size -1)
        if exclude_index is None or exclude_index != index:
            return index

def cross(chromo1, chromo2):
    # Получив двух родителей, мы можем провести скрещивание.
    # Его суть в том, чтобы каким-то образом перемешать гены двух родителей
    # и получить новую хромосому-потомка.
    # Здесь также есть куча методов и мы опять возьмем что попроще.
    # Это будет одноточечный кроссинговер.
    # Мы выбираем случайную позицию внутри хромосомы и потомок получает
    # гены родителя №1 от начала и до этой позиции и гены родителя №2
    # от этой позиции и до конца.
    # 
    # Каждые два родителя порождают пару потомков. Т.е. ф-цию cross()
    # мы вызываем дважды: сначала с (родитель1, родитель2), затем с (родитель2, родитель1)
    size = chromo1.size
    point = randint(0, size - 1)
    child = Chromosome(size, None)
    for i in range(point):
        child.genes[i] = chromo1.genes[i]
    for i in range(point, size):
        child.genes[i] = chromo2.genes[i]
    return child

def mutate(population, chromo_count, gene_count, gene_pool):
    # можно подвергать мутации хоть 50% популяции, 
    # но вот кол-во генов лучше задать 1.
    # Это значит, что за 1 раз мутирует только один символ в строке.
    # Были нередки случаи, когда строка была уже почти правильная,
    # то есть отличалась всего одним символом, но если после мутации
    # в ней меняется больше чем один символ, мы наоборот
    # отдаляемся от цели.
    pop_size = len(population)
    gene_pool_size = len(gene_pool)
    for i in range(chromo_count):
        chromo_pos = randint(0, pop_size - 1)
        chromo = population[chromo_pos]
        for j in range(gene_count):
            gene_pos = randint(0, gene_pool_size - 1)
            gene = gene_pool[gene_pos]
            gene_pos = randint(0, chromo.size - 1)
            chromo.genes[gene_pos] = gene

# Для собственного удобства сделаем более аккуратный вывод популяции
# на печать с порядковым номмером и рейтингом:

def print_population(population):
    i = 0
    for chromo in population:
        i += 1
        print(str(i) + '. ' + str(chromo.rating) + ': ' + chromo.genes.decode())
# Генофонд - это строка-справочник, которая содержит все возможные гены. 
# Его и финальную строку (по-научному: хромосому) закодируем в
# байтовые массивы.

gene_pool = bytearray(b'abcdefgghijklmnopqrstuvwxyz ') # можно рус. алфавит, если надо
final_chromo = bytearray(b'i love geekbrains') # целевая фраза
chromo_size = len(final_chromo)
population_size = 20

# В нашем случае мы для селекции возьмем метод элит. У нас будет элита
# в виде лучшей популяции, которая будет переходить в новую популяцию и 
# порождать потомков, чтобы заполнить вторую половину новой популяции.
# 
# Список хромосом уже отсортирован по рейтингу и поэтому задача селекции
# решена (берем топ-10), но ради будущей реализации др. методов нам надо
# сделать формальный отбор. Т.е. - поместим наших избранников в список
# "выживших".
# 
# Заведем для выживших список фиксированной длины заранее и будем им
# пользоваться все время:
survivors = [None] * (population_size // 2)

population = create_population(population_size, chromo_size, gene_pool)
iteration_count = 0

while True:
    iteration_count += 1 # счетчик поколения
    calc_rating(population, final_chromo) # расчет рейтинга популяции
    sort_population(population) # сорт-ка популяции, в начале элита
    print('*** ' + str(iteration_count) + ' ***')
    print_population(population) # печатаем популяцию
    if population[0].rating == 0:
        # При достижении целевой строки у первой хромосомы в списке будет 
        # рейтинг = 0. Обнаружив такое условие, мы прекращаем цикл,
        # т.к. цель достигнута.
        # Мы также печатаем текущую популяцию на каждом шаге цикла:
        break
    #if iteration_count == 20: break # если нужны первые 20 итераций цикла эволюции
    select(population, survivors) # отбор элиты - родителей в первую очередь
    repopulate(population, survivors, population_size // 2) # 2-ю часть популяции заполняем детьми
    mutate(population, 10, 1, gene_pool) # выполняем мутацию по 1 гену
