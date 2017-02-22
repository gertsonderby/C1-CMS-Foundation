import { Schema, arrayOf } from 'normalizr';

export const dataFieldSchema = new Schema('dataFieldDefs', { idAttribute: 'name' });

export const fieldsetSchema = new Schema('fieldsetDefs', { idAttribute: 'name' });
fieldsetSchema.define({
	fields: arrayOf(dataFieldSchema)
});

export const tabSchema = new Schema('tabDefs', { idAttribute: 'name' });
tabSchema.define({
	fieldsets: arrayOf(fieldsetSchema),
});

export const providerSchema = new Schema('providerDefs', { idAttribute: 'name' });

export const itemSchema = new Schema('itemDefs', { idAttribute: 'name' });
itemSchema.define({
	provider: providerSchema
});

export const toolbarSchema = new Schema('toolbarDefs', { idAttribute: 'name' });
toolbarSchema.define({
	items: arrayOf(itemSchema)
});

export const dialogPaneSchema = new Schema('dialogPaneDefs', { idAttribute: 'name' });
dialogPaneSchema.define({
	providers: arrayOf(providerSchema),
	buttons: arrayOf(itemSchema)
});

export const dialogSchema = new Schema('dialogDefs', { idAttribute: 'name' });
dialogSchema.define({
	panes: arrayOf(dialogPaneSchema)
});

export const pageSchema = new Schema('pageDefs', { idAttribute: 'name' });
pageSchema.define({
	tabs: arrayOf(tabSchema),
	toolbars: arrayOf(toolbarSchema),
	dialog: dialogSchema,
	providers: arrayOf(providerSchema)
});

export default arrayOf(pageSchema);
