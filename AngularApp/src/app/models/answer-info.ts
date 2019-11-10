import { FormGroup } from '@angular/forms';

export interface AnswerInfo {
    answersSubmitted: boolean;
    answersUpdating: boolean;
    numberOfAnswers: number;
    answerForm: FormGroup;
}
