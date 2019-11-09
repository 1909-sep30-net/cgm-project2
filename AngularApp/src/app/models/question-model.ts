import Answer from '../models/answer-model';
export default interface QuestionModel {
    titleId: number;
    questionString: string;
    answers? : Answer[];
};
