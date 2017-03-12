import { Treatment } from './treatment';

export const TREATMENTS: Treatment[] = [
	{ id: 1, name: 'Load Accounting Data Enrichment', description: 'Enrichment of data', lastRunDate: Date.now().toString(), type: 'statutory', status: 'error' },
	{ id: 2, name: 'Data Enrichment', description: 'Enrichment of data', lastRunDate: Date.now().toString(), type: 'statutory', status: 'success' },
	{ id: 3, name: 'Generate Report Accouting Data', description: 'Generates Report Accounting Data', lastRunDate: Date.now().toString(), type: 'statutory', status: 'inprogress' }
];