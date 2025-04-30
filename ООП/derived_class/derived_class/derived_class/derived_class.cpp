#include <iostream>
#include "PokemonTrainer.h"
#include "Pokemon.h"

int main() {
    try {
        // Создаем тренера
        PokemonTrainer trainer("Эш");

        // Добавляем покемонов в команду тренера
        trainer.addPokemon(new Pokemon("Пикачу", 10));
        trainer.addPokemon(new FirePokemon("Чармандер", 12));
        trainer.addPokemon(new WaterPokemon("Сквиртл", 15));
        trainer.addPokemon(new GrassPokemon("Бульбазавр", 14));

        // Вывод состава команды
        trainer.showTeam();

        // Тренировка команды (повышение уровня)
        trainer.trainTeam();

        // Демонстрация атаки покемонов из команды
        std::cout << "\nПокемоны из команды атакуют:" << std::endl;
        trainer.showTeam();

        // Создание временных покемонов для демонстрации атаки
        Pokemon* temp1 = new FirePokemon("Вульпикс", 11);
        Pokemon* temp2 = new WaterPokemon("Псайдак", 13);

        temp1->attack();
        temp2->attack();

        delete temp1;
        delete temp2;
    }
    catch (const std::exception& e) {
        std::cerr << "Ошибка: " << e.what() << std::endl;
    }
    catch (...) {
        std::cerr << "Произошло неизвестное исключение." << std::endl;
    }

    return 0;
}
