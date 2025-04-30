#include "PokemonTrainer.h"
#include <iostream>
#include <exception>

PokemonTrainer::PokemonTrainer(const std::string& name) : trainerName(name) {}

PokemonTrainer::~PokemonTrainer() {
    // Освобождение памяти, выделенной для покемонов
    for (auto p : team) {
        delete p;
    }
    team.clear();
}

void PokemonTrainer::addPokemon(Pokemon* p) {
    if (!p) {
        throw std::invalid_argument("Нельзя добавить пустой указатель на покемона");
    }
    team.push_back(p);
    std::cout << "Покемон добавлен в команду тренера " << trainerName << std::endl;
}

void PokemonTrainer::showTeam() {
    std::cout << "\nКоманда тренера " << trainerName << ":" << std::endl;
    for (auto p : team) {
        p->display();
    }
}

void PokemonTrainer::trainTeam() {
    std::cout << "\nТренировка команды " << trainerName << " началась!" << std::endl;
    for (auto p : team) {
        p->levelUp();
    }
}
