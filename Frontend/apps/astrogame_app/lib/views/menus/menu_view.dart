import 'package:astrogame_app/configurations/service_container.dart';
import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/menus/menu_item_listing.dart';
import 'package:astrogame_app/views/menus/menu_viewmodel.dart';
import 'package:enhanced_future_builder/enhanced_future_builder.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class MenuView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<MenuViewModel>.reactive(
      builder: (context, model, _) => Container(
        color: AstroGameColors.darkGrey,
        child: Column(
          children: [
            _header(context, model),
            _content(context, model),
            _footer(),
          ],
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }

  Widget _header(BuildContext context, MenuViewModel model) {
    return Container(
      padding: EdgeInsets.all(16),
      child: Stack(
        children: [
          EnhancedFutureBuilder<ImageProvider>(
            future: model.getSpeciesImageAsync(),
            rememberFutureResult: true,
            whenDone: (data) => Expanded(
              child: Container(
                height: 120,
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(16),
                  image: DecorationImage(
                    fit: BoxFit.fitHeight,
                    image: data,
                  ),
                ),
              ),
            ),
            whenNotDone: Container(
              height: 200,
              child: CircularProgressIndicator(),
            ),
          ),
          SizedBox(width: 16),
          Column(
            children: [
              Text(
                model.playerName,
                style: Theme.of(context).textTheme.headline2,
              ),
            ],
          ),
        ],
      ),
    );
  }

  Widget _content(BuildContext context, MenuViewModel model) {
    return Expanded(
      child: Padding(
        padding: const EdgeInsets.only(left: 0, right: 16),
        child: MenuItemListing(
          navigationService: getIt.get(),
          selectedItem: model.selectedItem,
          itemSelectedCallback: (item) => {
            model.navigate(item),
          },
        ),
      ),
    );
  }

  Widget _footer() {
    return SizedBox.shrink();
  }
}
