export class TaskItem
{
    public id: string = "";

    constructor(
        public description: string = "",
        public isComplete: boolean = false,
        public completedDate: Date | null = null,
        public createdDate: Date | null = null
    ) { }
}