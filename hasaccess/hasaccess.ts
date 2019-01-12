export class Bruv {
    public user: User;

    public hasAccess<T>(object: T, accessRight?: CRUD): boolean {
        
        if (this.gettype(object) === 'Person') {
            return (this.user.crud === (<Person>object).crud)
        } else if (this.gettype(object) === 'Mandate') {
            return (this.user.organization.containsOneOf((<Mandate>object).organization));
        } else if (this.gettype(object) === 'Artifact') {
            // return (this.user.organization.containsOneOf((<Mandate>object).organization) &&  )
            var artifact = <Artifact>object;
            var artifactOrganizations = artifact.mandates.forEachWithReturn(mandate => {return mandate.organization});
            var userOrganization = this.user.organization 
            return (artifactOrganizations.includes(userOrganization) && (this.user.crud === accessRight || (!artifact && this.user.crud === CRUD.Read)));     
        }
    }

    private gettype(object: any): string {
        return 'bruuder dis is a string';
    }

    Array.containsOneOf(yes: any[]): boolean {
        return true;
    }
    
}

enum CRUD {
    Create,
    Read,
    Update,
    Delete
}

class User {
    public crud: CRUD;
    public organization: any[];
}

class Mandate {
    public organization: any[];
}

class Artifact {
    public mandates: Mandate[];
}

class Person {
    public crud: CRUD;
}