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
    sort_population(population) # 
    print('*** ' + str(iteration_count) + ' ***') #
    print_population(population) # 
    if population[0].rating == 0:
