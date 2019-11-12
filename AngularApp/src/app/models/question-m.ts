import { AnswerM } from './answer-m';

export interface QuestionM {

    QuestionId: number;
    TitleId: number;
    QuestionString: string;
    answers: AnswerM[];

};
