import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/helpers/number_formatter.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/menus/resource_viewmodel.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class ResourceView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<ResourceViewModel>.reactive(
      builder: (context, model, _) => Container(
        height: 20,
        padding: EdgeInsets.only(left: 8, right: 8),
        color: AstroGameColors.darkGrey,
        child: ListView.separated(
          itemBuilder: (context, index) => _storedResourceWidget(
              context, model, model.storedResources[index]),
          separatorBuilder: (context, index) => SizedBox(width: 8),
          itemCount: model.storedResources.length,
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }

  Widget _storedResourceWidget(BuildContext context, ResourceViewModel model,
      StoredResource storedResource) {
    var resource = model.getResource(storedResource.resourceId);

    return Row(
      children: [
        Text(
          resource.name,
          style: Theme.of(context).textTheme.bodyText1,
        ),
        SizedBox(width: 8),
        Text(
          NumberFormatter.format(storedResource.amount, 2),
          style: Theme.of(context).textTheme.bodyText1,
        ),
        SizedBox(width: 4),

        // hourly prodution
        Text(
          '(${NumberFormatter.format(storedResource.hourlyAmount, 0)})',
          style: Theme.of(context).textTheme.bodyText1,
        ),
      ],
    );
  }
}
