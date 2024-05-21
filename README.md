# Genetic Algorithms in Unity

## Overview

This project demonstrates the implementation of Genetic Algorithms (GAs) within the Unity environment. Genetic Algorithms are search heuristics inspired by the process of natural selection that belong to the larger class of evolutionary algorithms (EA). They are commonly used to generate high-quality solutions to optimization and search problems by relying on bio-inspired operators such as mutation, crossover, and selection.

## What is a Genetic Algorithm?

A Genetic Algorithm (GA) is a method used to solve both constrained and unconstrained optimization problems based on a natural selection process that mimics biological evolution. The algorithm repeatedly modifies a population of individual solutions. At each step, the GA selects individuals from the current population to be parents and uses them to produce the children for the next generation. Over successive generations, the population evolves toward an optimal solution.

### Key Concepts of Genetic Algorithms

1. **Population**: A set of candidate solutions to the optimization problem.
2. **Chromosomes**: Representation of a solution. Each individual in the population has a chromosome, which can be a binary string, array, etc.
3. **Fitness Function**: Evaluates how close a given solution is to the optimum.
4. **Selection**: The process of choosing individuals based on their fitness to reproduce and create offspring.
5. **Crossover (Recombination)**: A genetic operator used to combine the genetic information of two parents to generate new offspring.
6. **Mutation**: A genetic operator used to maintain genetic diversity within the population by randomly tweaking the genes of individuals.
7. **Generations**: The iterations the algorithm goes through to evolve the solutions.

## Implementation in Unity

In this Unity project, we apply Genetic Algorithms to solve various problems such as pathfinding, character behavior optimization, and procedural content generation. The GA implementation in Unity involves the following steps:

1. **Initialization**: Generate an initial population of candidate solutions.
2. **Evaluation**: Use a fitness function to evaluate the quality of each candidate solution.
3. **Selection**: Select parents based on their fitness scores.
4. **Crossover**: Combine pairs of parents to produce offspring.
5. **Mutation**: Apply random changes to offspring to introduce genetic diversity.
6. **Replacement**: Form a new population by selecting the best individuals from the current population and the offspring.
7. **Iteration**: Repeat the evaluation, selection, crossover, mutation, and replacement steps for a number of generations or until a satisfactory solution is found.

## Getting Started

To explore the project and understand the implementation of Genetic Algorithms in Unity, follow these steps:

1. Clone or download the repository to your local machine.
2. Open the project in Unity Editor (version 2020.3.8f1 or higher).
3. Navigate to the scene files located in the `Assets/Scenes` directory.
4. Select a scene to open and observe how Genetic Algorithms are applied to solve different problems.
5. Review the scripts in the `Assets/Scripts` directory to understand the implementation of GA components such as population, selection, crossover, and mutation.
6. Experiment with different parameters and fitness functions to see how they affect the performance and outcomes of the Genetic Algorithm.

## Resources and References

- [Unity Documentation](https://docs.unity3d.com/)
- [Genetic Algorithms - Introduction](https://www.geeksforgeeks.org/genetic-algorithms/)
- [A Beginner's Guide to Genetic Algorithms](https://towardsdatascience.com/genetic-algorithms-explained-a-beginners-guide-6588e8f6a2f)
- [Evolving Unity Games with Genetic Algorithms](https://gamedevelopment.tutsplus.com/tutorials/unity-evolving-games-with-genetic-algorithms--cms-25152)

For more detailed information on Genetic Algorithms and their implementation in Unity, refer to the provided resources and documentation.

## Contributors

- [Murilo Boratto](https://github.com/muriloboratto)
- [Vinicius Santos](https://github.com/vimsos)

If you'd like to contribute to the project or have any suggestions, feel free to submit pull requests or open issues.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
