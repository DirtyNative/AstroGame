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
            _header(context),
            _content(context, model),
            _footer(),
          ],
        ),
      ),
      viewModelBuilder: () => new MenuViewModel(getIt.get()),
    );
  }

  Widget _header(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(16),
      child: Row(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
            width: 85,
            height: 119,
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(16),
              image: DecorationImage(
                image: AssetImage('assets/images/species.png'),
              ),
            ),
          ),
          SizedBox(width: 16),
          Column(
            children: [
              Text(
                'Profile',
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
        padding: const EdgeInsets.only(left: 16, right: 16),
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
