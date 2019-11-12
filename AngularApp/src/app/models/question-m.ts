import { AnswerM } from './answer-m';

export interface QuestionM {

    questionId: number;
    titleId: number;
    questionString: string;
    answers: AnswerM[];

};
