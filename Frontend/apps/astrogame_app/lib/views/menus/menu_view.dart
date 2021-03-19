import 'package:astrogame_app/configurations/service_container.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/menus/menu_item_listing.dart';
import 'package:astrogame_app/views/menus/menu_viewmodel.dart';
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
            _header(),
            _content(context, model),
            _footer(),
          ],
        ),
      ),
      viewModelBuilder: () => new MenuViewModel(getIt.get()),
    );
  }

  Widget _header() {
    return Container(
      height: 128,
      color: Colors.red,
    );
  }

  Widget _content(BuildContext context, MenuViewModel model) {
    return Padding(
      padding: const EdgeInsets.only(left: 16, right: 16),
      child: MenuItemListing(
        navigationService: getIt.get(),
        selectedItem: model.selectedItem,
        itemSelectedCallback: (item) => {
          //model.selectedItem = item,
          model.navigate(item),
        },
      ),
    );
  }

  Widget _footer() {
    return SizedBox.shrink();
  }
}
