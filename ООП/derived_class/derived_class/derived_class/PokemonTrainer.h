#ifndef POKEMONTRAINER_H
#define POKEMONTRAINER_H

#include <vector>
#include <string>
#include "Pokemon.h"

// Класс тренера покемонов, управляющий командой
class PokemonTrainer {
private:
    std::string trainerName;
    std::vector<Pokemon*> team;
public:
    PokemonTrainer(const std::string& name);
    ~PokemonTrainer();
    void addPokemon(Pokemon* p);
    void showTeam();
    void trainTeam();
};

#endif // POKEMONTRAINER_H
