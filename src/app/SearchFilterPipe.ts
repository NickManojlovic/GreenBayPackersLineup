import { Pipe,PipeTransform} from '@angular/core';

@Pipe({
    name: 'searchFilter'
})
export class SearchFilter implements PipeTransform {
    transform(items: any[], criteria: any): any {
        if (!items || !criteria) {
            return items;
        }

        return items.filter(item => item.fullName.toLowerCase().indexOf(criteria.toLowerCase()) !== -1);
    }
}