#ifndef POKEMON_H
#define POKEMON_H

#include <iostream>
#include <string>
#include <exception>

// Базовый класс для покемонов
class Pokemon {
protected:
    std::string name;
    int level;
public:
    Pokemon(const std::string& name, int level);
    virtual void attack();
    virtual void display();
    virtual void levelUp();
    virtual ~Pokemon();
};

// Класс-наследник для огненных покемонов
class FirePokemon : public Pokemon {
public:
    FirePokemon(const std::string& name, int level);
    void attack() override;
    void display() override;
};

// Класс-наследник для водных покемонов
class WaterPokemon : public Pokemon {
public:
    WaterPokemon(const std::string& name, int level);
    void attack() override;
    void display() override;
};

// Класс-наследник для травяных покемонов
class GrassPokemon : public Pokemon {
public:
    GrassPokemon(const std::string& name, int level);
    void attack() override;
    void display() override;
};

#endif // POKEMON_H
