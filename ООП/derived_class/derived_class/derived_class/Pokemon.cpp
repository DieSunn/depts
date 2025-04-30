#include "Pokemon.h"

// Реализация конструктора базового класса
Pokemon::Pokemon(const std::string& name, int level) : name(name), level(level) {
    if (level < 0) {
        throw std::invalid_argument("Уровень покемона не может быть отрицательным");
    }
}

void Pokemon::attack() {
    std::cout << name << " атакует базовой атакой!" << std::endl;
}

void Pokemon::display() {
    std::cout << "Покемон: " << name << ", Уровень: " << level << std::endl;
}

void Pokemon::levelUp() {
    level++;
    std::cout << name << " поднял уровень до " << level << "!" << std::endl;
}

Pokemon::~Pokemon() {}

// Реализация класса FirePokemon
FirePokemon::FirePokemon(const std::string& name, int level) : Pokemon(name, level) {}

void FirePokemon::attack() {
    std::cout << name << " использует огненный удар!" << std::endl;
}

void FirePokemon::display() {
    std::cout << "Огненный Покемон: " << name << ", Уровень: " << level << std::endl;
}

// Реализация класса WaterPokemon
WaterPokemon::WaterPokemon(const std::string& name, int level) : Pokemon(name, level) {}

void WaterPokemon::attack() {
    std::cout << name << " использует водный удар!" << std::endl;
}

void WaterPokemon::display() {
    std::cout << "Водный Покемон: " << name << ", Уровень: " << level << std::endl;
}

// Реализация класса GrassPokemon
GrassPokemon::GrassPokemon(const std::string& name, int level) : Pokemon(name, level) {}

void GrassPokemon::attack() {
    std::cout << name << " использует ядовитый удар!" << std::endl;
}

void GrassPokemon::display() {
    std::cout << "Травяной Покемон: " << name << ", Уровень: " << level << std::endl;
}
