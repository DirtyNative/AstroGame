import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'resource_amount.g.dart';

@GuidConverter()
@JsonSerializable()
class ResourceAmount {
  double amount;
  Guid resourceId;

  ResourceAmount();

  factory ResourceAmount.fromJson(Map<String, dynamic> json) => _$ResourceAmountFromJson(json);
  Map<String, dynamic> toJson() => _$ResourceAmountToJson(this);
}
