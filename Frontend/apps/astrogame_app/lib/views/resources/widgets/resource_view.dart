import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/helpers/number_formatter.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';
import 'package:astrogame_app/models/resources/element.dart' as resources;
import 'package:astrogame_app/models/resources/material.dart' as resources;

import 'resource_viewmodel.dart';

class ResourceView extends StatelessWidget {
  final Resource _resource;

  ResourceView(this._resource);

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<ResourceViewModel>.reactive(
      builder: (context, model, _) {
        return Container(
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(16),
            color: AstroGameColors.lightGrey,
          ),
          child: Row(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              (model.resource is resources.Element)
                  ? Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: _elementIconWidget(
                          context, model.resource as resources.Element),
                    )
                  : _materialIconWidget(
                      context, model.resource as resources.Material),
              SizedBox(width: 16),
              Column(
                mainAxisAlignment: MainAxisAlignment.center,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(model.resource!.name),
                  Row(
                    children: [
                      Text(NumberFormatter.format(model.storedAmount, 2,
                          fullNumbers: true)),
                      SizedBox(width: 16),
                      (model.storedResource == null)
                          ? SizedBox.shrink()
                          : Text(
                              NumberFormatter.format(
                                  model.storedResource?.hourlyAmount ?? 0, 2,
                                  fullNumbers: true),
                              style: Theme.of(context)
                                  .textTheme
                                  .bodyText2!
                                  .copyWith(
                                      color:
                                          (model.storedResource!.hourlyAmount >
                                                  0)
                                              ? Colors.green
                                              : Colors.red),
                            ),
                    ],
                  ),
                ],
              )
            ],
          ),
        );
      },
      viewModelBuilder: () => ServiceLocator.get(param1: _resource),
    );
  }

  Widget _elementIconWidget(BuildContext context, resources.Element element) {
    return Container(
      height: 50,
      width: 50,
      decoration: BoxDecoration(
        color: AstroGameColors.mediumGrey,
        borderRadius: BorderRadius.circular(8),
        border: Border.all(color: Colors.white, width: 3),
      ),
      child: Stack(
        children: [
          Positioned(
            child: Center(
              child: Text(
                element.symbol,
                textAlign: TextAlign.center,
                style: Theme.of(context).textTheme.headline2,
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget _materialIconWidget(
      BuildContext context, resources.Material material) {
    return Container(
      height: 50,
      width: 50,
      child: Center(
        child: Text(
          material.name.substring(0, 1),
          style: Theme.of(context).textTheme.headline2,
        ),
      ),
    );
  }
}
