import { Injectable } from '@angular/core';
import { Treatment } from '../../models/treatment';

import { TREATMENTS } from '../../models/mock-treatment';


@Injectable()
export class TreatmentService {
	getTreatments(): Promise<Treatment[]> {
		return Promise.resolve(TREATMENTS);
	}

	getTreatment(id: number): Promise<Treatment> {
		return this.getTreatments().then(treatments=> treatments.find(t=>t.id === id));
	}
}