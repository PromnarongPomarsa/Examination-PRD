export interface ListQuestionDto {
    id: number;
    question: string;
    choiceFirst: string;
    choiceSecond: string;
    choiceThird: string;
    choiceFourth: string;
    createDate: Date;
}