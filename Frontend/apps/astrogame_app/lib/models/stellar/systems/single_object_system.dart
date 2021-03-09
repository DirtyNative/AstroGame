import 'package:astrogame_app/converters/guid_converter.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_system.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'single_object_system.g.dart';

@GuidConverter()
@JsonSerializable()
class SingleObjectSystem extends StellarSystem {
  @JsonKey()
  Guid parentId;

  @JsonKey()
  StellarSystem parent;

  @JsonKey()
  int order;

  @JsonKey()
  List<StellarSystem> satellites;

  @JsonKey()
  StellarObject centerObject;

  @JsonKey()
  Guid centerObjectId;

  SingleObjectSystem(
    Guid id,
    String name,
    this.parentId,
    this.parent,
    this.order,
    this.satellites,
    this.centerObject,
    this.centerObjectId,
  ) : super(id, name);

  factory SingleObjectSystem.fromJson(Map<String, dynamic> json) =>
      _$SingleObjectSystemFromJson(json);
  Map<String, dynamic> toJson() => _$SingleObjectSystemToJson(this);
}
