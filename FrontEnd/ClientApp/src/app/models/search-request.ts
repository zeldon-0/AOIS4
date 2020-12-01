export class SearchRequest{
    public epochs : number;
    public populationSize : number;
    public mutationProbability : number;
    public constructor(epochs: number, populationSize : number, mutationProbability : number){
        this.epochs = epochs;
        this.populationSize = populationSize;
        this.mutationProbability = mutationProbability;
    }
}