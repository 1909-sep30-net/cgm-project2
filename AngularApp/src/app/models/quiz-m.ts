import { TitleM } from './title-m';
import { QuestionM } from './question-m';
import CategoryModel from './category-model';

export interface QuizM {//this may need default
    title: TitleM;
    questions: QuestionM[];
    categories: CategoryModel[];
    score: number;
};
