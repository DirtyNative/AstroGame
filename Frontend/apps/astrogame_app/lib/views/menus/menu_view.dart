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
      height: 180,
      padding: EdgeInsets.all(0),
      child: Stack(
        children: [
          // Background image
          Image.asset(
            'assets/images/bakground_species.jpg',
            height: 180,
            fit: BoxFit.fitHeight,
          ),

          // Species Image

          EnhancedFutureBuilder<ImageProvider>(
            future: model.getSpeciesImageAsync(),
            rememberFutureResult: true,
            whenDone: (data) => Positioned(
              bottom: 0,
              left: 20,
              child: Image(
                image: data,
                height: 120,
              ),
            ),
            whenNotDone: Container(
              height: 100,
              child: CircularProgressIndicator(),
            ),
          ),

          // Player name
          SizedBox(width: 16),
          Text(
            model.playerName,
            style: Theme.of(context).textTheme.headline2,
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
