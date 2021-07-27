import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';

import 'package:json_annotation/json_annotation.dart';

part 'colonized_stellar_object.g.dart';

@GuidConverter()
@JsonSerializable()
class ColonizedStellarObject {
  late Guid id;
  late Guid playerId;
  late DateTime colonizedOn;
  late Guid stellarObjectId;

  ColonizedStellarObject();

  factory ColonizedStellarObject.fromJson(Map<String, dynamic> json) =>
      _$ColonizedStellarObjectFromJson(json);
  Map<String, dynamic> toJson() => _$ColonizedStellarObjectToJson(this);
}
